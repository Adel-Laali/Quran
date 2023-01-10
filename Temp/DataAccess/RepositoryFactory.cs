namespace Saeed.Quran.DataAccess
{
    public class RepositoryFactory
    {
        public static Repositories.ChapterNoteRepository ChapterNote
        {
            get
            {
                return new Repositories.ChapterNoteRepository();
            }
        }

        public static Repositories.ChapterNoteRepository ChapterNoteFrom(string databaseName = null)
        {
            return new Repositories.ChapterNoteRepository(databaseName);
        }

        public static Repositories.QuranNoteRepository QuranNote
        {
            get
            {
                return new Repositories.QuranNoteRepository();
            }
        }

        public static Repositories.QuranNoteRepository QuranNoteFrom(string databaseName = null)
        {
            return new Repositories.QuranNoteRepository(databaseName);
        }

        public static Repositories.StrongVerseRepository StrongVerse
        {
            get
            {
                return new Repositories.StrongVerseRepository();
            }
        }

        public static Repositories.StrongVerseRepository StrongVerseFrom(string databaseName = null)
        {
            return new Repositories.StrongVerseRepository(databaseName);
        }

        public static Repositories.TopicRepository Topic
        {
            get
            {
                return new Repositories.TopicRepository();
            }
        }

        public static Repositories.TopicRepository TopicFrom(string databaseName = null)
        {
            return new Repositories.TopicRepository(databaseName);
        }

        public static Repositories.TopicVerseRepository TopicVerse
        {
            get
            {
                return new Repositories.TopicVerseRepository();
            }
        }

        public static Repositories.TopicVerseRepository TopicVerseFrom(string databaseName = null)
        {
            return new Repositories.TopicVerseRepository(databaseName);
        }

        public static Repositories.VerseNoteRepository VerseNote
        {
            get
            {
                return new Repositories.VerseNoteRepository();
            }
        }

        public static Repositories.VerseNoteRepository VerseNoteFrom(string databaseName = null)
        {
            return new Repositories.VerseNoteRepository(databaseName);
        }
    }
}
