local chunk, load_error = loadfile(arg[1])
if not chunk then
    io.stderr:write("SPIRAL-LUA-LOAD-ERROR " .. tostring(load_error) .. "\n")
    os.exit(97)
end
local result = chunk()
io.stdout:flush()
if type(result) == "number" then os.exit(result) end
os.exit(0)
