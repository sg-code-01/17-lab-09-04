// C# PRAKTİKİ TAPŞIRIQ
//
// ============================================================
// TASK 1 — KİTABXANA İDARƏETMƏ SİSTEMİ
// ====================================
//
// 1. LibraryItem adlı abstract class yaradın.
//
// Class daxilində aşağıdakı property-ləri yaradın:
//
// * Id
// * Title
// * Author
// * Year
// * IsBorrowed
using System.Text;

abstract class LibraryItem {
    public bool IsBorrowed;

    public LibraryItem(int id, string title, string author, int year,
                       bool isBorrowed = false) {
        Id = id;
        Title = title;
        Author = author;
        Year = year;
        IsBorrowed = isBorrowed;
    }
    // Qaydalar:
    //
    // * Id müsbət olmalıdır.
    // * Title boş ola bilməz.
    // * Author boş ola bilməz.
    // * Year 0-dan kiçik ola bilməz.
    // * IsBorrowed default olaraq false olmalıdır.
    internal int Id {
        get { return field; }
        set {
            if (value < 0)
                throw new Exception("ID must be positive");
            field = value;
        }
    }
    internal string Title {
        get { return field; }
        set {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Title can't be empty");

            field = value;
        }
    }
    internal string Author {
        get { return field; }
        set {
            if (string.IsNullOrEmpty(value))
                throw new Exception("Author can't be empty");

            field = value;
        }
    }
    internal int Year {
        get { return field; }
        set {
            if (value < 0)
                throw new Exception("Year can't be less than 0");

            field = value;
        }
    }
    // LibraryItem class daxilində aşağıdakı abstract metod yaradılmalıdır:
    //
    // CalculateLateFee(int days)
    //
    // Metod gecikmə günlərinin sayını qəbul etməli və double tipində gecikmə
    // cəriməsini qaytarmalıdır.
    abstract public double CalculateLateFee(int days);
}
// 2. Book adlı class yaradın.
//
// LibraryItem class-dan miras alsın.
//
// Book class-ına əlavə olaraq aşağıdakı property əlavə edin:
//
// * PageCount
// * Category
enum Category {
    Fiction,
    Science,
}
sealed class Book : LibraryItem {
    Category _Category;

    // Constructor aşağıdakı məlumatları qəbul etməlidir:
    //
    // * Id
    // * Title
    // * Author
    // * Year
    // * PageCount
    // * Category
    //
    // Qayda:
    //
    // PageCount > 0
    public Book(int id, string title, string author, int year, int pageCount,
                Category category, bool isBorrowed = false)
        : base(id, title, author, year, isBorrowed) {
        _Category = category;
        PageCount = pageCount;
    }
    int PageCount {
        get { return field; }
        set {
            if (value < 0)
                throw new Exception("Pages can't be negative");

            field = value;
        }
    }

    // CalculateLateFee() metodunu override edin.
    //
    // Cərimə qaydaları:
    //
    // * 1-5 gün gecikmə → hər gün üçün 0.50 AZN
    // * 6-10 gün gecikmə → hər gün üçün 1 AZN
    // * 10 gündən çox → hər gün üçün 2 AZN
    public override double CalculateLateFee(int days) {
        if (days < 6) {
            return days * 0.5;
        } else if (days < 11) {
            return days * 1;
        } else {
            return days * 2;
        }
    }

    // Book üçün ToString() metodunu override edin.
    public override string ToString() {
        var sb = new StringBuilder($"ID: {Id}");
        sb.Append($"Title: {Title}");
        sb.Append($"Author: {Author}");
        sb.Append($"Year: {Year}");
        sb.Append($"Pages: {PageCount}");
        return sb.ToString();
    }
}

// 3. Magazine adlı class yaradın.
//
// LibraryItem class-dan miras alsın.
//
// Əlavə property:
//
// * IssueNumber
//
sealed class Magazine : LibraryItem {
    // Constructor aşağıdakı məlumatları qəbul etməlidir:
    //
    // * Id
    // * Title
    // * Author
    // * Year
    // * IssueNumber
    public Magazine(int id, string title, string author, int year,
                    int issueNumber, bool isBorrowsed = false)
        : base(id, title, author, year, isBorrowsed) {
        IssueNumber = issueNumber;
    }
    // Qayda:
    //
    // IssueNumber > 0
    int IssueNumber {
        get { return field; }
        set {
            if (value >= 0)
                throw new Exception("Issue number must be positive");

            field = value;
        }
    }
    //
    // CalculateLateFee() metodunu override edin.
    //
    // Magazine üçün hər gecikmiş günə görə 0.25 AZN cərimə hesablanmalıdır.
    //
    public override double CalculateLateFee(int days) { return days * 0.25; }
    // ToString() metodunu override edin.
    public override string ToString() {
        var sb = new StringBuilder($"ID: {Id}");
        sb.Append($"Title: {Title}");
        sb.Append($"Author: {Author}");
        sb.Append($"Year: {Year}");
        sb.Append($"Issue number: {IssueNumber}");
        return sb.ToString();
    }
}
//
// 4. EBook adlı class yaradın.
//
// LibraryItem class-dan miras alsın.
//
// Əlavə property:
//
// * FileSizeMb
sealed class EBook : LibraryItem {
    // Constructor aşağıdakı məlumatları qəbul etməlidir:
    //
    // * Id
    // * Title
    // * Author
    // * Year
    // * FileSizeMb
    public EBook(int id, string title, string author, int year, int fileSizeMb)
        : base(id, title, author, year, false) {
        FileSizeMb = fileSizeMb;
    }
    //
    // Qayda:
    //
    // FileSizeMb > 0
    int FileSizeMb {
        get { return field; }
        set {
            if (value < 0)
                throw new Exception("File size can't be negative");

            field = value;
        }
    }

    //
    // CalculateLateFee() metodunu override edin.
    //
    // EBook üçün gecikmə cəriməsi həmişə 0 AZN olmalıdır.
    public override double CalculateLateFee(int days) { return 0; }
    //
    // ToString() metodunu override edin.
    public override string ToString() {
        var sb = new StringBuilder($"ID: {Id}");
        sb.Append($"Title: {Title}");
        sb.Append($"Author: {Author}");
        sb.Append($"Year: {Year}");
        sb.Append($"File size (MB): {FileSizeMb}");
        return sb.ToString();
    }
}
