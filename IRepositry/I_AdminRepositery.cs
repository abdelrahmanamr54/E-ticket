using E_ticket.Models;
using E_ticket.ViewModel;

namespace E_ticket.IRepositry
{
    public interface I_AdminRepositery
    {
        void GetNewCatagory(CategoryVM categoryVM);
         void GetNewMovie();

        void add_New_Movie(MovieVM movieVM);


         MovieStatus GetMovieStatus(DateTime StartDate, DateTime EndDate);
        Movie editMovie(int id);


        void EditMovie(MovieVM movie);
    }
}
//string name, string Description, double Price, string ImgUrl, string TrailerUrl, DateTime StartDate, DateTime EndDate, int CinemaId, int CategoryId)