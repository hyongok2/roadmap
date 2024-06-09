
using FacetedBuilder;

Person person = new PersonBuilder().Lives
                                    .In("Korea").WithPostcode("11111").At("Seoul")
                                   .Works
                                    .At("Samsung").AsA("CEO").Earning(123000);

Console.WriteLine(person);