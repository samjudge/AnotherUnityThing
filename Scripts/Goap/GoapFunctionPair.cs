using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GoapFunctionPair
{
    public GoapHeuristicFunction Heuristic;
    public GoapActionFunction Action;

    public GoapFunctionPair(
        GoapHeuristicFunction Heuristic,
        GoapActionFunction Action
    ) {
        this.Heuristic = Heuristic;
        this.Action = Action;
    }
}