# BulkImageResizeInC-.net
Bulk ImageResizeIn C#.net

This code work with subfolder also.


Download Poject 

Do Below Changes in App.config file

<add key="input_source" value="xxxxx" />  Image source folder path 


<add key="output_source" value="xxx\" />  Image destination folder path


<add key="resize_width" value="480" />  fixed width


<add key="resize_height" value="0" /> if height 0 then image height set on aspect ratio.


e.g Image folder

input_source="C:\Users\XXX\Desktop\image_filter"

output_source="C:\Users\XXX\Desktop\image_filter\Output\"



Input Image 

C:\Users\XXX\Desktop\image_filter\test\image1.png

C:\Users\XXX\Desktop\image_filter\test\image2.png




Output Image 


C:\Users\XXX\Desktop\image_filter\Output\test\image1.png

C:\Users\XXX\Desktop\image_filter\Output\test\image2.png

