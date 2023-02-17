'use client'

const fs = require('fs')
const path = require('path')
import { marked } from 'marked'
import {
    notFound,
    useRouter,
} from 'next/navigation'

const Concept = async ({ params }) => {

    const urlSegments = params.concept || []
    const diskSegments = [process.cwd(), 'contents', 'concepts'].concat(urlSegments)
    var filePath = path.join.apply(null, [...diskSegments, 'index.html'])
    if (!fs.existsSync(filePath)) {
        filePath = path.join.apply(null, [...diskSegments, 'index.md'])
    }
    if (!fs.existsSync(filePath)) {
        filePath = path.join.apply(null, [...diskSegments]) + '.md'
    }
    if (!fs.existsSync(filePath)) {
        filePath = path.join.apply(null, [...diskSegments]) + '.html'
    }
    console.log(filePath)
    let type = "html"
    let content = ""
    if (!fs.existsSync(filePath)) {
        notFound()
    }
    else {
        content = fs.readFileSync(filePath, 'utf8')
        if (filePath.endsWith('.md')) {
            type = 'markdown'
            if (content.charCodeAt(0) == 65279) {
                content = content.slice(1)
            }
            content = await marked.parse(content)
        }
    }

    const router = useRouter()

    return <>
        <div
            onClick={() => router.push('/')}
            className="p-5 cursor-pointer"
        >
            Home
        </div>
        <div
            className={type + (type === 'markdown' ? ' prose pl-10 mb-10 pt-4' : '')}
            dangerouslySetInnerHTML={{ __html: content }}
        />
    </>
}

export default Concept
