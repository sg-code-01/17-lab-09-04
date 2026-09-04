// 2 Sample Books (assuming Category is an enum)
var book1 =
    new Book(1, "1984", "George Orwell", 1949, 328, Category.Fiction, false);
var book2 = new Book(2, "To Kill a Mockingbird", "Harper Lee", 1960, 281,
                     Category.Fiction);

// 1 Sample Magazine
var magazine = new Magazine(3, "National Geographic", "Various", 2023, 512);

// 1 Sample EBook
var eBook = new EBook(4, "Clean Code", "Robert C. Martin", 2008, 15);

// Console.WriteLine(book1.CalculateLateFee(2));
// Console.WriteLine(book2.CalculateLateFee(12));
// Console.WriteLine(magazine.CalculateLateFee(7));
// Console.WriteLine(eBook.CalculateLateFee(100));

// Console.WriteLine(LibraryExtensions.GetLateFee(book1, 12));
// Console.WriteLine(book1);
// Console.WriteLine(magazine);
// Console.WriteLine(eBook);

var service = new LibraryService();
service.AddItem(book1);
service.AddItem(book1);
service.AddItem(book2);
service.AddItem(magazine);
service.AddItem(eBook);

service.BorrowItem(book2.Id);
service.BorrowItem(book2.Id);

service.BorrowItem(eBook.Id);
service.BorrowItem(eBook.Id);
service.BorrowItem(eBook.Id);

service.ReturnItem(book1.Id);
service.ReturnItem(book1.Id);

LibraryExtensions.GetShortInfo(book1);
LibraryExtensions.GetStatus(book2);
