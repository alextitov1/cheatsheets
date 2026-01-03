**ETCD** 

ETCD (/etc distributed) is a distributed reliable key-value store that is Simple, Secure and Fast.

## Tools

```sh
etcdctl version

etcdctl put foo bar
etcdctl get foo
```

## Installation

```sh
curl -LO https://github.com/coreos/etcd/releases/download/v3.5.0/etcd-v3.5.0-linux-amd64.tar.gz

tar -xzvf etcd-v3.5.0-linux-amd64.tar.gz

mv etcd-v3.5.0-linux-amd64/etcd* /usr/local/bin/

mkdir -p /etc/etcd /var/lib/etcd
```

```
#etcd systemd unit file
ExecStart=/usr/local/bin/etcd \
  --name ${ETCD_NAME} \
  --data-dir /var/lib/etcd \
  --listen-peer-urls https://${ETCD_NAME}:2380 \
  --listen-client-urls https://${ETCD_NAME}:2379,https://${ETCD_NAME}:2379 \
  --advertise-client-urls https://${ETCD_NAME}:2379 \
  --initial-advertise-peer-urls https://${ETCD_NAME}:2380 \
  --initial-cluster ${ETCD_INITIAL_CLUSTER} \
  --initial-cluster-state new \
  --initial-cluster-token ${ETCD_INITIAL_CLUSTER_TOKEN} \
  --cert-file=/etc/etcd/etcd.pem \
  --key-file=/etc/etcd/etcd-key.pem \
  --peer-cert-file=/etc/etcd/etcd.pem \
  --peer-key-file=/etc/etcd/etcd-key.pem \
  --trusted-ca-file=/etc/etcd/ca.pem \
  --peer-trusted-ca-file=/etc/etcd/ca.pem \
  --client-cert-auth \
  --peer-client-cert-auth \
...
```



