using System.Web.Mvc;
using System.Threading.Tasks;

using mvc.vuejs.infrastructure;
using mvc.vuejs.infrastructure.Queries.Games;
using mvc.vuejs.infrastructure.Commands.Games;

namespace mvc.vuejs.example.Controllers
{
    public class HomeController : Controller
    {
        private readonly QueryDispatcher _queryDispatcher;

        private readonly CommandDispatcher _commandDispatcher;

        public HomeController(QueryDispatcher queryDispatcher, CommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, Route("games/get-games")]
        public async Task<JsonResult> GetGames()
        {
            return Json((await _queryDispatcher.DispatchAsync<GetGames.Query, GetGames.Result>(new GetGames.Query())), JsonRequestBehavior.AllowGet);
        }

        [HttpPost, Route("games/delete-game")]
        public async Task<JsonResult> DeleteGame(DeleteGame.Command command)
        {
            try
            {
                await _commandDispatcher.DispatchAsync<DeleteGame.Command>(command);
                return Json(new { Succeeded = true }, JsonRequestBehavior.AllowGet);
            }
            catch (CommandValidationException cex)
            {
                return Json(new { Succeeded = true, Error = cex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost, Route("games/create-game")]
        public async Task<JsonResult> AddGame(CreateGame.Command command)
        {
            try
            {
                await _commandDispatcher.DispatchAsync<CreateGame.Command>(command);
                return Json(new { Succeeded = true }, JsonRequestBehavior.AllowGet);
            }
            catch (CommandValidationException cex)
            {
                return Json(new { Succeeded = true, Error = cex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}