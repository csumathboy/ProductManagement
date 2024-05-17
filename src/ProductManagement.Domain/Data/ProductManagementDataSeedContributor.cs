using ProductManagement.Authors;
using ProductManagement.Books;
using ProductManagement.Categories;
using ProductManagement.Products;
using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Data
{
    public class ProductManagementDataSeedContributor :
           IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly IRepository<Product, Guid> _productRepository;

        private readonly IRepository<Book, Guid> _bookRepository;

        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;

        public ProductManagementDataSeedContributor(
            IRepository<Category, Guid> categoryRepository,
            IRepository<Product, Guid> productRepository, 
            IRepository<Book, Guid> bookRepository,
            IAuthorRepository authorRepository,
            AuthorManager authorManager)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
             _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            /***** TODO: Seed initial data here *****/
            if (await _bookRepository.GetCountAsync() > 0)
            {
                return;
            }

            var orwell = await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "George Orwell",
                    new DateTime(1903, 06, 25),
                    "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)."
                )
            );

            var douglas = await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "Douglas Adams",
                    new DateTime(1952, 03, 11),
                    "Douglas Adams was an English author, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
                )
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    AuthorId = orwell.Id, // SET THE AUTHOR
                    Name = "1984",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1949, 6, 8),
                    Price = 19.84f
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    AuthorId = douglas.Id, // SET THE AUTHOR
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    Type = BookType.ScienceFiction,
                    PublishDate = new DateTime(1995, 9, 27),
                    Price = 42.0f
                },
                autoSave: true
            );

            if (await _categoryRepository.CountAsync() > 0)
            {
                return;
            }
            var monitors = new Category { Name = "Monitors" };
            var printers = new Category { Name = "Printers" };
            await _categoryRepository.InsertManyAsync(new[] { monitors, printers });
            var monitor1 = new Product
            {
                Category = monitors,
                Name = "XP VH240a 23.8-Inch Full HD 1080p IPS LED  Monitor",
                Price = 163,
                ReleaseDate = new DateTime(2019, 05, 24),
                StockState = ProductStockState.InStock
            };
            var monitor2 = new Product
            {
                Category = monitors,
                Name = "Clips 328E1CA 32-Inch Curved Monitor, 4K UHD",
                Price = 349,
                IsFreeCargo = true,
                ReleaseDate = new DateTime(2022, 02, 01),
                StockState = ProductStockState.PreOrder
            };
            var printer1 = new Product
            {
                Category = monitors,
                Name = "Acme Monochrome Laser Printer, Compact All-In One",
                Price = 199,
                ReleaseDate = new DateTime(2020, 11, 16),
                StockState = ProductStockState.NotAvailable
            };
            await _productRepository.InsertManyAsync(new[] { monitor1, monitor2, printer1 });

           
        }
    }
}