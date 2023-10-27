using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cars.Models;

namespace Cars.Controllers
{
    public class CarController : Controller
    {
        private static IList<Car> cars = new List<Car>
        {
        new Car() { Id = 1, Brand = "Audi",Model = "A3", Price = 30000},
        new Car() { Id = 2, Brand = "BMW",Model = "X3", Price = 50000},
        new Car() { Id = 3, Brand = "Opel",Model = "Astra", Price = 15000}
        };

        // GET: CarController
        public ActionResult Index()
        {
            return View(cars);
        }

        // GET: CarController/Details/5
        public ActionResult Details(int id)
        {
            return View(cars.FirstOrDefault(x=> x.Id == id));

        }

        // GET: CarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            car.Id = cars.Count+1;
            cars.Add(car);
            return RedirectToAction("Index");

        }

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(cars.FirstOrDefault(x => x.Id == id));
        }

        // POST: CarController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car car)
        {
            Car car1 = cars.FirstOrDefault(x => x.Id == id);
            car1.Brand = car.Brand;
            car1.Model = car.Model;
            car1.Price = car.Price;
            return RedirectToAction("Index");

        }

        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(cars.FirstOrDefault(x => x.Id == id));
        }

        // POST: CarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Car car)
        {
            Car car1 =cars.FirstOrDefault(x => x.Id == id);
            cars.Remove(car1);
            return RedirectToAction("Index");
        }
    }
}
