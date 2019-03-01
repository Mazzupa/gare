package it.chad.googleHashCode2k19.solver;

import com.google.common.collect.Sets;
import it.chad.googleHashCode2k19.image.Image;
import org.checkerframework.checker.units.qual.A;

import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.List;

public class Solver {

  public static ArrayList<Image> solve(ArrayList<Image> images) {
    
    preProcess(images);
    
    Image[] array = new Image[images.size()];
    
    for (int i = 0; i < images.size(); i++) {
      array[i] = images.get(i);
    }

    ArrayList<ArrayList<Image>> combination = iterate_combinations(array);

    ArrayList<Image> best = new ArrayList<Image>();
    int scoreMax = -1;

    for (ArrayList<Image> i : combination) {
      if (i.size() < 2) continue;

      int score = 0;
      for (int j = 0; j < i.size() - 1; j++) {
        score += computeScore(i.get(j), i.get(j + 1));
      }
      if (score > scoreMax) {
        scoreMax = score;
        best = i;
      }
    }

    return best;
  }

  public static ArrayList<ArrayList<Image>> iterate_combinations(Image[] elems) {

    int n = elems.length;

    ArrayList<ArrayList<Image>> images = new ArrayList<ArrayList<Image>>();

    for (int num = 0; num < (1 << n); num++) {
      ArrayList<Image> combination = new ArrayList<Image>();
      for (int ndx = 0; ndx < n; ndx++) {
        if ((num & (1 << ndx)) != 0) {
          combination.add(elems[ndx]);
        }
      }
      images.add(combination);
    }

    return images;
  }

  public static int computeScore(Image image0, Image image1) {

    int innerJoin = Sets.intersection(image0.getTags(), image1.getTags()).size();
    int leftOuterJoin = Sets.difference(image0.getTags(), image1.getTags()).size();
    int rightOuterJoin = Sets.difference(image1.getTags(), image0.getTags()).size();

    return Math.min(innerJoin, Math.min(leftOuterJoin, rightOuterJoin));
  }
  
  public static void preProcess(ArrayList<Image> images) {
  
    Comparator<Image> comparator = new Comparator<Image>() {
      public int compare(final Image o1, final Image o2) {
        return o1.getTags().size() - o2.getTags().size();
      }
    };
    //(o1, o2) -> o1.getTags().size() - o2.getTags().size()
  
  
    ArrayList<Image> imageArrayList = new ArrayList<Image>();
    if(images.size() > 10) {
      //Collections.sort(images, comparator);

      for (int i = 0; i < 10; i++) {
        imageArrayList.add(images.get(i));
      }
    }
    
    images = imageArrayList;
    
    for (int i1 = 0; i1 < images.size(); i1++) {
      final Image i = images.get(i1);
      if (i.isVertical()) {
        images.remove(i);
      }
    }
  }
  
  
  public static void output(ArrayList<Image> images, String fileName) throws IOException {
  
    FileWriter fw = new FileWriter(fileName);
  
    fw.write(images.size()+"\n");
    for (Image i : images) {
      fw.write(i.getId() + "\n");
    }
    fw.flush();
  }
}
