using System.Collections.Generic;

public interface IPart
{
    void Shot();

    List<ICanon> GetCanonList();
}
