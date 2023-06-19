using Meeting_Manegment_System.Data;
using Meeting_Manegment_System.Interface;
using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private ApplicationDbContext _context;
        public DocumentRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public WordDocument GetFileByMeetingId(int id)
        {
            return _context.WordDocuments.Where(x => x.MeetingId == id).FirstOrDefault();
        }
        public bool Add(WordDocument wordDocument)
        {
            _context.Add(wordDocument);
            return Save();
        }

        public bool Delete(WordDocument wordDocument)
        {
            _context.Remove(wordDocument);
            return Save();
        }

        public WordDocument GetFileById(int id)
        {
            return _context.WordDocuments.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(WordDocument wordDocument)
        {
            _context.Update(wordDocument);
            return Save();
        }
    }
}