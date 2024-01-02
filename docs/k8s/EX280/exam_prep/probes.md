# Readiness

```sh
oc set probe deploy/long-load \
  --readiness --failure-threshold 1 --period-seconds 3 \
  --get-url http://:3000/health
```