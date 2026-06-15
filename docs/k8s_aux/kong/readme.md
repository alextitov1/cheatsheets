# Kong Gateway Application Architecture

* NGINX - kong is build on top of NGINX

* OpenResty - lua module for NGINX, used to extend NGINX with Lua scripts.
* Kong clustering and Datastore - Kong uses PostgreSQL for managing and storing data related to various entities and configurations, such as in a single instance deployment, or in a clustered environment.
* Kong Plugins - a modular extension. A plugin allows you to easily add new features to your API such as Authentication, Security, Traffic Control, transformation and logging.

* RESTful Administration API. - Admin API.


# Kong Gateway Deployment Modes

Self-Managed

Managed by Kong - Konnect


# Pricing Packages

- Kong Open-Source
- Kong Enterprise
- Kong Konnect


# Installation options

## Traditional Mode

in this mode Kong is installed on a virtual machine or physical server, and is managed by the user. All components(proxy, Admin API, database) are installed and on the same machine.

## DB-less Mode
In this mode, Kong is installed without a database. Config are set in a yaml file, admin API works in read only mode.


## Hybrid Mode


# Scaling dimensions

- **Latency** - microseconds or milliseconds. Memory-bound. The delay between the downstream client sending a request and receiving a response.

- **Throughput** - requests per second. CPU-bound. The number of requests that can be processed by the system in a given time span.

## Ports

### Proxy Ports
The proxy ports are the only ports that should be made available to your clients. Upstream services are accessible via the proxy interfaces and ports.

- 8000 - http - proxy_listen - take incoming HTTP traffic and forward it to the appropriate upstream services.
- 8443 - https - proxy_listen - take incoming HTTPS traffic and forward it to the appropriate upstream services.

You can also proxy TCP/TLS steams, which is disabled by default. see `stream_listen` in the configuration file.

### Admin Ports

- 8001 - http - admin_listen - used for managing and configuring Kong via the Admin API.
- 8444 - https - admin_listen - used for managing and configuring Kong via the Admin API.

### Other Ports

- 8002 - http - admin_gui_listen - used for accessing the Kong Manager GUI.
- 8445 - https - admin_gui_listen - used for accessing the Kong Manager GUI.

- 8005 - tcp - cluster_listen - Hybrid mode only. Control plane listens for traffic from data plane nodes.
- 8006 - tcp - cluster_telemetry_listen -  Hybrid mode only. Control plane listens for Vitals telemetry data from data plane nodes.
- 8007 - tcp - status_listen - Status listener. Listens for calls from monitoring clients over HTTP.