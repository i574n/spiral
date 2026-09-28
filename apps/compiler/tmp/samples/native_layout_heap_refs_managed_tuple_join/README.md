# Native heap reference managed tuple join

Exercises a managed tuple containing a recursive optional node and a scalar behind heap references. Replacement clones the tuple transitively in Delphi, aliases retain shared container identity, and teardown releases the nested node. The expected exit code is 42.
