using E_ticket.Data;
using E_ticket.IRepositry;
using Microsoft.AspNetCore.Mvc;

namespace E_ticket.Repositery
{
    public class ActorRepositery : I_ActorRepositery
    {
        ApplicationDbContext Context = new ApplicationDbContext();
        public Models.Actor ActorDetails(int id)
        {

            var selectedactor = Context.actors.Single(e => e.Id == id);


            return selectedactor;
        }


    }
}
