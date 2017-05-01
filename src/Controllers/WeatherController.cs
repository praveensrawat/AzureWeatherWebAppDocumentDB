namespace weather.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using weather.Models;

    public class WeatherController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocDBClass<Weather>.GetItemsAsync(d => d.Severe);
            return View(items);
        }

#pragma warning disable 1998
        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }
#pragma warning restore 1998

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Id,Location,Temperature,Severe")] Weather item)
        {
            if (ModelState.IsValid)
            {
                await DocDBClass<Weather>.CreateItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "Id,Name,Description,Completed")] Weather item)
        {
            if (ModelState.IsValid)
            {
                await DocDBClass<Weather>.UpdateItemAsync(item.Id, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Weather item = await DocDBClass<Weather>.GetItemAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [ActionName("Delete")]
        public async Task<ActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Weather item = await DocDBClass<Weather>.GetItemAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmedAsync([Bind(Include = "Id")] string id)
        {
            await DocDBClass<Weather>.DeleteItemAsync(id);
            return RedirectToAction("Index");
        }

        [ActionName("Details")]
        public async Task<ActionResult> DetailsAsync(string id)
        {
            Weather item = await DocDBClass<Weather>.GetItemAsync(id);
            return View(item);
        }
    }
}