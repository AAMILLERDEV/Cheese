namespace lib;

public class Data {
    public Task<Cheddar[]> SendCheddars(){
        var cheddarList = new List<Cheddar>
        {

        };

        return Task.FromResult(cheddarList.ToArray());
    }
}