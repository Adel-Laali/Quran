'use client'

import {
    use,
    useMemo,
    useState,
} from 'react'
import { useRouter } from 'next/navigation'

const Index = () => {

    const fetchPromise = useMemo(() => fetch('https://api.quran.com/api/v3/chapters').then(r => r.json()), [])

    const chapters = use(fetchPromise)

    const [tab, setTab] = useState('chapters');

    const router = useRouter()

    const goToChapter = (chapter) => {
        router.push(`/${chapter.chapter_number}`);
    }

    const goToConcepts = () => router.push('/concepts/index')

    const goToChapters = () => setTab('chapters')

    return <>
        <h1 className="py-4 flex items-center justify-around text-5xl font-bold">
            <span className='cursor-pointer' onClick={goToConcepts}>Concepts</span>
            <span className='cursor-pointer' onClick={goToChapters}>Surahs</span>
        </h1>
        {
            tab === 'chapters'
                ?
                <ul id='chapters' className="flex flex-wrap flex-grow mx-12 mb-4 justify-center">
                    {
                        chapters?.map(
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
