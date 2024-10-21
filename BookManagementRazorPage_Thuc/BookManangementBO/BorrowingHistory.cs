using System;
using System.Collections.Generic;

namespace BookManangementBO;

public partial class BorrowingHistory
{
    public int BorrowId { get; set; }

    public int AccountId { get; set; }

    public int BookId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Book Book { get; set; } = null!;
}
