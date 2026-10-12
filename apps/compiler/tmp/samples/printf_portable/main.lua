local v0 = 60
local v1 = -9000000000
local v2 = 200
local v3 = "cube"
io.write(v3, ": ", string.format("%d", v0), " frames, checksum ", string.format("%d", 970392), "\n")
io.write("big ", string.format("%.0f", v1 + 0.0), ", small ", string.format("%d", -5), ", byte ", string.format("%d", v2), "\n")
io.write("100% {braces} \"quoted\" \\ tab\tend\n")
io.write("literal", "\n")
io.write(v3)
io.write("\n")
return 0
