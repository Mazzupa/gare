package it.chad.googleHashCode2k19.main;

import it.chad.googleHashCode2k19.parser.Parser;
import it.chad.googleHashCode2k19.solver.Solver;

import java.io.IOException;

public class Main {
  public static void main(String[] args) throws IOException {

    String[] files = {"a", "b", "c", "d", "e"};

    for (String i : files) {
      
      Solver.output(Solver.solve(Parser.parse("in/" + i + ".txt")),("out/" + i + ".txt"));
      
    }
  }
}
