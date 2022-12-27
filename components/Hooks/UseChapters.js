import { getFromCacheOrApi } from 'Base'

const useChapters = async () => {
    const chapters = await getFromCacheOrApi('https://api.quran.com/api/v3/chapters')
    return chapters
}

export default useChapters;
