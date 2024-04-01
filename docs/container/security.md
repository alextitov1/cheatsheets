### shared resources:
    * dentry - is a directory entry in the kernel's dentry cache
    * inodes - shared by all containers


### privileged
Docker run <image> --privileged vs (--cap-drop=ALL --cap-add=setuid)

Distroless 

FROM scratch

export DOCKER_CONTENT_TRUST=1
  - verify publisher
  - tags


# Links

https://sysdig.com/blog/container-isolation-gone-wrong/
