'use client'

import { useRef } from 'react'
import quran from "../../Contents/quran"

const Random = async () => {
    const chapter = Math.ceil(Math.random() * 114)
    const verseCount = quran.filter(i => i.chapter * 1 === chapter)[0].verseCount
    const verse = Math.ceil(Math.random() * verseCount)

    const link = useRef()

    const reload = (e) => {
        link.current.click()
        setTimeout(() => {
            window.location.reload()
        }, 1000)
        e.stopPropagation()
        e.preventDefault()
    }

    return <div onClick={(e) => reload()} className="flex w-screen h-screen items-center justify-center">
        <a ref={link} className="text-5xl" target='_blank' href={`/${chapter}/${verse}`}>{chapter}:{verse}</a>
    </div>
}

export default Random
