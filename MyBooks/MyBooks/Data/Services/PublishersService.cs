using MyBooks.Data.Models;
using MyBooks.Data.ViewModels;

namespace MyBooks.Data.Services
{
    public class PublishersService
    {

        private AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisherVM)
        {
            Publisher publisher = new Publisher()
            {
                Name=publisherVM.Name,
            };

            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }



        public List<Publisher> GetAllPublishers() => _context.Publishers.ToList();
        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(x => x.Id == id);



        public Publisher UpdatePublisherById(int id, PublisherVM newPublisher)
        {
            Publisher dbPublisher = _context.Publishers.FirstOrDefault(x => x.Id == id);

            if (dbPublisher != null)
            {
                dbPublisher.Name = newPublisher.Name;
            }
            _context.SaveChanges();


            return dbPublisher;
        }


        public void DeletePublisherById(int id)
        {
            Publisher dbPublisher = _context.Publishers.FirstOrDefault(x => x.Id == id);
            if (dbPublisher != null)
            {
                _context.Publishers.Remove(dbPublisher);
                _context.SaveChanges();
            }



        }
    }
}
