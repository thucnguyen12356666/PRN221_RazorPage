using System;
using System.Collections.Generic;

namespace BookManangementBO;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string Author { get; set; } = null!;

    public string Publisher { get; set; } = null!;

    public int? YearPublished { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<BorrowingHistory> BorrowingHistories { get; set; } = new List<BorrowingHistory>();
}
