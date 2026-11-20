program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$IFDEF WINDOWS}{$MAXSTACKSIZE $10000000}{$ENDIF}
uses {$IFDEF UNIX}cthreads, {$ENDIF}SysUtils, Math;
function method0: Boolean; forward;
function method0: Boolean;
begin
  Result := True;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: LongInt;
  v3: LongInt;
  v4: Boolean;
  v5: Boolean;
  v6: LongInt;
  v7: LongInt;
begin
  v0 := 0;
  v1 := 0;
  while method0 do begin
      v3 := v0 + 1;
      v0 := v3;
      v4 := v0 < 3;
      if v4 then begin
          continue;
      end else begin
          v5 := v0 >= 6;
          if v5 then begin
              break;
          end else begin
              v6 := v1 + v0;
              v1 := v6;
          end;
      end;
  end;
  v7 := v1 - 12;
  Result := v7;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
var SpiralExitCode: LongInt;
procedure SpiralRun;
begin
  {$IFDEF WINDOWS}SetTextCodePage(Output, CP_UTF8); SetTextCodePage(StdErr, CP_UTF8);{$ENDIF}
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  SpiralExitCode := SpiralMain;
  Flush(Output);
end;
{$IFNDEF WINDOWS}
function SpiralThreadMain(p: Pointer): PtrInt;
begin
  SpiralRun;
  Result := 0;
end;
var SpiralThread, SpiralThreadId: TThreadID;
{$ENDIF}
begin
  {$IFDEF WINDOWS}
  SpiralRun;
  Halt(SpiralExitCode);
  {$ELSE}
  SpiralThread := BeginThread(@SpiralThreadMain, nil, SpiralThreadId, 268435456);
  WaitForThreadTerminate(SpiralThread, 0);
  Halt(SpiralExitCode and 255);
  {$ENDIF}
end.
