const { app, BrowserWindow } = require('electron');
const { spawn } = require('child_process');

let djangoProcess;

function createWindow () {
  const win = new BrowserWindow({
    width: 1000,
    height: 700,
    title: "AVW_CRM"
  });

  win.loadURL('http://localhost:8000');
}