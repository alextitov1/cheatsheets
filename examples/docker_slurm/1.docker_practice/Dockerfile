FROM python:3.6-slim-buster
RUN ln -snf /usr/share/zoneinfo/Oceania/Auckland /etc/localtime && echo Oceania/Auckland > /etc/timezone

WORKDIR /app

RUN apt-get update -y \
    && apt-get install -y curl

COPY requirements.txt .

RUN pip install -r requirements.txt

COPY app.py .

RUN useradd app

USER app
EXPOSE 8000
ENTRYPOINT python app.py


