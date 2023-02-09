const fs = require('fs')
const path = require('path')
import { marked } from 'marked'
import getAhlolbaitUrl from '../../../Contents/ahlolbait'

const notFound = { errorCode: 404 }

const getData = async ({ chapter, verse }) => {
    if (isNaN(chapter * 1)) {
        return notFound
    }
    if (chapter * 1 > 114 || chapter * 1 < 1) {
        return notFound
    }
    if (isNaN(verse * 1)) {
        return notFound
    }

    const response = await fetch('https://api.quran.com/api/v3/chapters')
    const chapters = await response.json()
    const chapterJson = chapters.chapters.filter(i => i.chapter_number == chapter)[0]
    if (verse * 1 > chapterJson.verses_count || verse * 1 < 1) {
        return notFound
    }
    const diskSegments = [process.cwd(), 'Contents', 'surahs'].concat(chapter.toString().padStart(3, '0'), verse.toString().padStart(3, '0') + '.md')
    var filePath = path.join.apply(null, [...diskSegments])
    console.log(filePath)
    if (!fs.existsSync(filePath)) {
        return notFound
    }
    var verseText = await fetch(`https://api.alquran.cloud/v1/ayah/${chapter * 1}:${verse * 1}`)
        .then(response => {
            return response.json()
        })
        .then(data => {
            return data.data.text
        })
        .catch(error => {
            console.log(error)
        })
    try {
        var content = fs.readFileSync(filePath, 'utf8')
        if (content.charCodeAt(0) == 65279) {
            content = content.slice(1)
        }
        // content = `<base target="_blank">\n${content}`
        content = marked.parse(content)
        const ahlolbaitUrl = getAhlolbaitUrl(chapterJson.chapter_number, verse * 1)
        const corpusUrl = `https://corpus.quran.com/wordbyword.jsp?chapter=${chapterJson.chapter_number}&verse=${verse * 1}`
        const result = {
            chapter: chapterJson,
            content,
            verseText,
            verse: verse * 1,
            corpusUrl,
            ahlolbaitUrl
        }
        return result
    } catch (e) {
        console.log(e)
        const result = { chapter: chapterJson, errorCode: 500 }
        return result
    }
}

const ChapterAndVerse = async ({ params }) => {

    const {
        ahlolbaitUrl,
        chapter,
        content,
        corpusUrl,
        errorCode,
        verse,
        verseText,
    } = await getData(params)


    if (errorCode) {
        return <h1>Error - {errorCode}</h1>
    }

    const html =
        '<div class="md:grid grid-cols-2 gap-6">'
        + '<div class="prose p-5 m-5">'
        + `<h1>${chapter.name_simple} - ${chapter.name_arabic}</h1>`
        + `<h2><a target="_blank" href="https://quran.com/${chapter.chapter_number}/${verse}">${chapter.chapter_number} - ${verse}</a></h2>`
        + `<p class="text-2xl leading-10 pr-10" dir="rtl">${verseText}</p>`
        + `<div><a target="_blank" href="${corpusUrl}">Corpus</a></div>`
        + `<div><a target="_blank" href="${ahlolbaitUrl}">Ahlolbait</a></div>`
        + `<div><a target="_blank" href="https://quran.com/${chapter.chapter_number}/${verse}?translations=131,85,17,207,149,19,167,84,203,206,20,95,171,57,22,173,136,31,779,233,81,143,118,29,135,172,210,77,52,124,112,158,234,54,156,151,97,101,127,55,122">Translations</a></div>`
        + `<div><a target="_blank" href="https://www.google.com/search?q=nouman+ali+khan+${chapter.chapter_number}+${chapter.name_simple}+${verse}+guiding+directions&oq=nouman+ali+khan+4+nisa+100&aqs=chrome..69i57j69i61.327j0j1&sourceid=chrome&ie=UTF-8">Nouman Ali Khan</a></div>`
        + '</div>'
        + '<div class="prose p-5 m-5 md:h-full md:fixed md:overflow-scroll md:right-0 md:w-1/2">'
        + '<base target="_blank">'
        + content
        + '</div>'
        + '</div>'

    return <div
        dangerouslySetInnerHTML={{ __html: html }}
    >
    </div>
}


export default ChapterAndVerse
