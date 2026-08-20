Pass 2: interfaces split by what the caller does
  ThumbnailMaker  DiskFileStore   cover.png 256 bytes -> 64 bytes
  ThumbnailMaker  PackageStore    logo.png 128 bytes -> 32 bytes
  Publisher       DiskFileStore   published cover.thumb.png
  PackageStore is not an IWriteFiles, so Publisher will not take it.
  That line is commented out in Program.cs. Uncomment it to see.
