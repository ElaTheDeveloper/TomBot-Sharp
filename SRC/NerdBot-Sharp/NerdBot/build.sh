#!/bin/bash
dotnet publish -c Release -r linux-x64 -p:PublishReadyToRun=true
