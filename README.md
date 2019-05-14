# mem-optimized-web-crawler

I wrote a crawler that visits web pages, stores a few keywords in a database, and follows links to other web pages.  
I noticed that my crawler was wasting a lot of time visiting the same pages over and over, so I made a unordered set, visited, where I'm storing URLs I've already visited. Now the crawler only visits a URL if it hasn't already been visited.  
Thing is, the crawler is running on my old desktop computer in my parents' basement (where I totally don't live anymore), and it keeps
running out of memory because visited is getting so huge.  
How can I trim down the amount of space taken up by visited?  

# Gotchas

Your strategy shouldn't take a hit on runtime  
Replacing common substrings like ".com" and "www" with characters that are not allowed in URLs definitely wins us something, but we can do even better.  
How can we further exploit overlaps or shared prefixes between URLs?  
