namespace lab_2_0
{
    public abstract class BookDecorator : Book
    {
        protected Book _book;

        public BookDecorator(Book book)
        {
            this._book = book;
        }

        public new virtual string GetBookDescription()
        {
            return this._book.GetBookDescription();
        }
    }

    public class BookWithRating : BookDecorator
    {
        // Свойство рейтинга с дефолтным значением
        public double Rating { get; set; } = 0.0;

        public BookWithRating(Book book)
            : base(book) { }

        public override string GetBookDescription()
        {
            return $"{base.GetBookDescription()}, Rating: {this.Rating}";
        }
    }

    public class BookWithWiewStatus : BookDecorator
    {
        // Свойство просмотра с дефолтным значением
        public bool ViewStatus { get; set; } = false;

        public BookWithWiewStatus(Book book)
            : base(book) { }

        public override string GetBookDescription()
        {
            return $"{base.GetBookDescription()}, View Status: {this.ViewStatus}";
        }
    }
}
