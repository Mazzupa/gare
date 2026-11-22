package it.chad.googleHashCode2k19.image;

import java.util.HashSet;
import java.util.Set;

public class Image {

  private int id;
  private Set<String> tags = new HashSet<String>();
  private boolean isVertical;

  public Image() {}

  public Image(final int id) {
    this.id = id;
  }

  public Image(final int id, final boolean isVertical) {
    this.id = id;
    this.isVertical = isVertical;
  }

  public int getId() {
    return id;
  }

  public void setId(final int id) {
    this.id = id;
  }

  public Set<String> getTags() {
    return tags;
  }

  public void setTags(final Set<String> tags) {
    this.tags = tags;
  }

  public void addTag(String tag) {
    this.tags.add(tag);
  }

  public boolean isVertical() {
    return isVertical;
  }

  public void setVertical(final boolean vertical) {
    isVertical = vertical;
  }

  @Override
  public String toString() {
    //return "Image{" + "id=" + id + ", tags=" + tags + ", isVertical=" + isVertical + '}';
    return ""+id;
  }
}
