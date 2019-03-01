package it.chad.googleHashCode2k19.parser;

import it.chad.googleHashCode2k19.image.Image;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

public class Parser {

  public static ArrayList<Image> parse(String filePath) {

    ArrayList<Image> images = new ArrayList<>();
    try {

      Scanner scanner = new Scanner(new File(filePath));

      int numImage = Integer.parseInt(scanner.nextLine());

      for (int i = 0; i < numImage; i++) {

        String[] data = scanner.nextLine().split(" ");

        Image image = new Image(i, data[0].equals("V"));
        for (int j = 2; j < Integer.parseInt(data[1]) + 2; j++) {

          image.addTag(data[j]);
        }

        images.add(image);
      }

    } catch (IOException e) {
      e.printStackTrace();
    }

    return images;
  }
}
