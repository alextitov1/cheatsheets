# attach env from secret

```sh
oc set env deployment/demo \
--from secret/demo-secret --prefix MYSQL_
```