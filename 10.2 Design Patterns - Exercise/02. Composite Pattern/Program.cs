using Composite_Pattern;

SingleGift phone = new("Phone", 20);
phone.CalculateTotalPrice();
Console.WriteLine();

var phoneTools = new CompositeGift("PHONE", 0);
var sim = new SingleGift("sim", 15);
var @case = new SingleGift("case", 25);

phoneTools.Add(sim);
phoneTools.Add(@case);


var morePhoneTools = new CompositeGift("More Phone Tools", 50);
var airPods = new SingleGift("AirPods", 200);

morePhoneTools.Add(airPods);

phoneTools.Add(morePhoneTools);

Console.WriteLine($"The total price of this composite present is: {phoneTools.CalculateTotalPrice()} lv.");