using System;

namespace Biob.Services.Data.DtoModels
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //I'm having second thoughs about this "Length" as a string of xhours and xminutes, instead of an integer that represents seconds. 
        //I know we discussed but i doubt that this is smartest.
        //Wouldn't it make sense to always handle everything in the api the easiest and fastest way?
        //I would think that by putting the formatting on the client's workload, we keep the server as clean and fast as possible
        public string Length { get; set; }
        public string Poster { get; set; }
        public string Producer { get; set; }
        public string Actors { get; set; }
        public string Genre { get; set; }
        public DateTimeOffset Released { get; set; }
        public bool ThreeDee { get; set; }
        public int AgeRestriction { get; set; }
    }
}
