public abstract class Item
{
    
    protected string _name;
    protected int _quantity;
    protected decimal _price;

    public Item(string name, int quantity, decimal price)
    {
        _name = name;
        _quantity = quantity;
        _price = price;
    }

    public virtual string getInfo()
    {
        return $"{_name}: {_quantity} units at ${_price} each";
    }
}