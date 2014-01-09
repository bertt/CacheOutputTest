CacheOutputTest
===============
/api/test has output caching, /api/test2 has not

Test:
- Run project
- curl http://localhost:50848/api/test
returns "test" (json mediatype) -> ok
- curl http://localhost:50848/api/test2 
returns "test" (json mediatype) -> ok
- curl http://localhost:50848/api/test2 -H "accept:text/html"
return <html>html:test</html> (html mediatype) -> ok
- curl http://localhost:50848/api/test -H "accept:text/html"
expected: <html>html:test</html> (html mediatype)
actual: test (json mediatype) -> not ok

fix:
- curl http://localhost:50848/api/test3 
returns "test" (json mediatype) -> ok
- curl http://localhost:50848/api/test3 -H "accept:text/html"
return <html>html:test</html> (html mediatype) -> ok :-)




