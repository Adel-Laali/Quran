'use client'

import { useState } from 'react'
import { useRouter } from 'next/router'

const Index = async () => {

    const response = await fetch('https://api.quran.com/api/v3/chapters')
    const chapters = await response.json()

    const [tab, setTab] = useState('chapters');

    // const router = useRouter()

    // const goToChapter = (chapter) => {
    //     router.push(`/${chapter.chapter_number}`);
    // }

    return <>
        <h1 className="py-4 flex items-center justify-around text-5xl font-bold">
            <span className='cursor-pointer' onClick={() => router.push('/concepts/index')}>Concepts</span>
            <span className='cursor-pointer' onClick={() => setTab('chapters')}>Surahs</span>
        </h1>
        {
            tab === 'chapters'
                ?
                <ul id='chapters' className="flex flex-wrap flex-grow mx-12 mb-4 justify-center">
                    {
                        chapters.map(
                            chapter => <li key={chapter.chapter_number} onClick={() => goToChapter(chapter)} className="m-1 py-2 px-4 bg-green-200 rounded cursor-pointer hover:bg-green-900 hover:text-white transition-all duration-200">
                                <div className="text-xs font-bold">{chapter.chapter_number}</div>
                                <div className="my-1 font-medium">{chapter.name_simple}</div>
                                <div className="text-xs text-right">{chapter.name_arabic}</div>
                            </li>
                        )
                    }
                </ul>
                :
                <ul>
                    <li>hi</li>
                </ul>
        }
    </>
}

export default Index;
