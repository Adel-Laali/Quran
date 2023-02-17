'use client'

const fs = require('fs');
const path = require('path');
import { marked } from 'marked';
import { useRouter } from 'next/navigation'

const Concept = async () => {
    const diskSegments = [process.cwd(), 'Contents', 'surahs', 'notes'];
    var filePath = path.join.apply(null, [...diskSegments]) + '.md';
    console.log(filePath);
    var content = fs.readFileSync(filePath, 'utf8');
    content = marked.parse(content);
    const router = useRouter()

    return <>
        <div onClick={() => router.push('/')} className="p-5 cursor-pointer">Home</div>
        <div className='prose pl-10 mb-10 pt-4' dangerouslySetInnerHTML={{ __html: content }}></div>
    </>
}

export default Concept;
