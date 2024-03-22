// See https://aka.ms/new-console-template for more information

using Kontenery.Containers;
using Kontenery.Containerships;

LiquidContainer lq = new LiquidContainer(300.0, 20.0, 50.0, 1000.0, true);
lq.Load(120);
lq.info();
lq.Unload();
GasContainer ga = new GasContainer(400, 100, 40, 500, 30);
ga.Load(500);
ga.info();
ga.Unload();

CoolerContainer cc = new CoolerContainer(100, 200, 30, 300, "Bananas", 30);
cc.info();

ContainerShip cs1 = new ContainerShip(200, 5, 400);
cs1.AddContainer(lq);
cs1.AddContainer(ga);
cs1.AddContainer(cc);
cs1.info();




