namespace ObligatoriskOpg1Sem3
{
    public class Book
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public int Price { get; set; }

        //Properties with buildin non-specific exception handling  
        //public string Title {
        //    get { return Title; }
        //    set {
        //        if (value != null && value.Length >= 3)
        //        {
        //            Title = value;
        //        }
        //        else {
        //            throw new ArgumentException("Title must be a non-null string and more than 3 chars in length.");
        //        }
        //    } 
        //}
        //public int Price {
        //    get { return Price; }
        //    set
        //    {
        //        if (value > 0 && value <= 1200)
        //        {
        //            Price = value;
        //        }
        //        else
        //        {
        //            throw new ArgumentException("Price can't be less than 0 or higher than 1200.");
        //        }
        //    }
        //}


        public override string ToString()
        {
            return $"{Id} {Title} {Price}";
        }


        public bool ValidateTitle() 
        {
            if (Title == null)
            {
                throw new ArgumentNullException("Title can't be null.");
            }

            if(Title.Length <= 3)
            {
                throw new ArgumentException("Title must be more than 3 chars.");
            }
            return true;        
        }

        public bool ValidatePrice()
        {
            if(Price <= 0 || Price > 1200) 
            {
                throw new ArgumentOutOfRangeException("Price is not within the range of 0 < Price <= 1200.");
            }
            return true;
        }

        public void Validate() 
        {
            ValidateTitle();
            ValidatePrice();            
        }
    }
}