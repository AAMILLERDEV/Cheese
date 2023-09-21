using lib;
using Microsoft.AspNetCore.Mvc;

namespace CheeseController;

[ApiController]
public class CheeseController : ControllerBase {

    public readonly ICheddarRepository ch;
    public CheeseController(ICheddarRepository ch){
        this.ch = ch;
    }


    [HttpGet]
    [Route("[controller]/GetCheddars")]
    public async Task<IEnumerable<Cheddar>> GetCheddars() {
        try {
            return await this.ch.GetCheddar();
        } catch (Exception ex){
            Console.WriteLine(ex.Message);
            return null;
        }

    } 

    [HttpGet]
    [Route("[controller]/CalcLowest")]
    public async Task<int> CalcLowest() {
        try {
            return await this.ch.CalcLowest();
        } catch (Exception ex){
            Console.WriteLine(ex.Message);
            return 0;
        }

    }

    [HttpPost]
    [Route("[controller]/UpsertCheddar")]
    public Task<int?> UpsertCheddar(Cheddar ins)
    {
        try
        {
            return this.ch.UpsertCheddar(ins);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }

    }
}

