let v0 : string = "schema\tnode_id\toperation\tfrom\tto\tdeps\teffect\tcapability\tretry_budget\n1\tlookup\tLookupUser\trequest\trow\t\tidempotent\tquery\t2\n1\tcount\tCountTenants\trequest\tcount\t\tidempotent\tquery\t2\n1\tpair\tPairQuery\trow-count\tpaired\tlookup,count\tidempotent\tcompose\t1\n1\tmap\tMapQuery\tcount\tmapped\tcount\tidempotent\tmap\t1\n"
v0
