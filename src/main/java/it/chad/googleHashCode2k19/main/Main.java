package it.chad.googleHashCode2k19.main;

import it.chad.googleHashCode2k19.parser.Parser;
import it.chad.googleHashCode2k19.solver.Solver;

public class Main {
  public static void main(String[] args) {

    String[] files = {"a", "b", "c", "d", "e"};

    for (String i : files) {
      System.out.println(Solver.solve(Parser.parse(i + ".txt")));
    }
  }
}
