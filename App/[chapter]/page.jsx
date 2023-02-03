import { useRouter } from 'next/router'

const ChapterAndVerse = ({ chapter, errorCode }) => {

    const router = useRouter()

    const goToVerse = (verse) => {
        router.push(`/${chapter.chapter_number}/${verse}`);
    }

    if (errorCode) {
        return <h1>Error - {errorCode}</h1>
    }

    return <>
        <h1 className="flex py-4 text-5xl font-bold justify-center">{chapter.name_simple} <span className="text-sm ml-2">({chapter.chapter_number})</span></h1>
        <h3 className="flex py-2 text-3xl font-medium justify-center">{chapter.name_arabic}</h3>
        <ul id='verses' className="flex flex-wrap mx-12 mb-4 justify-center">
            {
                Array(chapter.verses_count).fill().map(
                    (x, i) => <li key={i} onClick={() => goToVerse(i + 1)} className="p-4 m-2 bg-green-200 rounded hover:bg-green-900 hover:text-white transition-all duration-200 cursor-pointer w-16 flex items-center justify-center">
                        {i + 1}
                    </li>)
            }
        </ul>
    </>
}

const notFound = { props: { errorCode: 404 } };

export async function getServerSideProps({ params, res }) {
    const chapterNumber = params.chapter;
    if (isNaN(chapterNumber * 1)) {
        res.statusCode = 404;
        return notFound;
    }
    if (chapterNumber * 1 > 114 || chapterNumber * 1 < 1) {
        res.statusCode = 404;
        return notFound;
    }

    const response = await fetch('https://api.quran.com/api/v3/chapters')
    const chapters = await response.json()
    const chapter = chapters.chapters.filter(i => i.chapter_number == chapterNumber)[0];
    return { props: { chapter } };
}

export default ChapterAndVerse;
