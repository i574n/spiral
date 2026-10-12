program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun0 = class
    function Invoke(a0: LongInt): AnsiString; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: AnsiString; function Invoke(v1: LongInt): AnsiString; override; end;
function ClosureCreate0(v0: AnsiString): TFun0; forward;
function Tf_c0.Invoke(v1: LongInt): AnsiString;
var
  v2: Boolean;
  v3: AnsiString;
begin
  v2 := v1 = 0;
  if v2 then begin
      v3 := 'no';
      Result := v3;
  end else begin
      Result := v0;
  end;
end;
function ClosureCreate0(v0: AnsiString): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: TFun0;
  v2: AnsiString;
  v3: Boolean;
begin
  v0 := 'hi';
  v1 := ClosureCreate0(v0);
  v2 := v1.Invoke(1);
  v3 := v2 = 'hi';
  if v3 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
