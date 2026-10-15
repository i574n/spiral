program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TUS0 = record tag: LongInt; c1_0: AnsiString; c2_0: AnsiString; end;
  TFun0 = class
    function Invoke(a0: LongInt): TUS0; virtual; abstract;
  end;
  Tclosure0 = class(TFun0)  function Invoke(v0: LongInt): TUS0; override; end;
function ClosureCreate0: TFun0; forward;
function method0(v0: TFun0): TUS0; forward;
function method1(v0: TFun0): TUS0; forward;
function US0_Idle: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Text(a0: AnsiString): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function US0_Note(a0: AnsiString): TUS0;
begin
  Result.tag := 2; Result.c2_0 := a0;
end;
function Tclosure0.Invoke(v0: LongInt): TUS0;
var
  v1: Boolean;
  v2: AnsiString;
  v4: AnsiString;
begin
  v1 := v0 = 1;
  if v1 then begin
      v2 := 'alpha';
      Result := US0_Text(v2);
  end else begin
      v4 := 'beta';
      Result := US0_Note(v4);
  end;
end;
function ClosureCreate0: TFun0;
var c: Tclosure0;
begin
  c := Tclosure0.Create; 
  Result := c;
end;
function method0(v0: TFun0): TUS0;
begin
  Result := v0.Invoke(1);
end;
function method1(v0: TFun0): TUS0;
begin
  Result := v0.Invoke(2);
end;
function SpiralMain: LongInt;
var
  v0: TFun0;
  v1: TUS0;
  v6: LongInt;
  v3: AnsiString;
  v2: AnsiString;
  v7: TUS0;
  v12: LongInt;
  v9: AnsiString;
  v8: AnsiString;
  v13: LongInt;
  v14: LongInt;
begin
  v0 := ClosureCreate0;
  v1 := method0(v0);
  case v1.tag of
      0: begin
          v6 := 3;
      end;
      2: begin
          v3 := v1.c2_0;
          v6 := 6;
      end;
      1: begin
          v2 := v1.c1_0;
          v6 := 5;
      end;
  end;
  v7 := method1(v0);
  case v7.tag of
      0: begin
          v12 := 3;
      end;
      2: begin
          v9 := v7.c2_0;
          v12 := 6;
      end;
      1: begin
          v8 := v7.c1_0;
          v12 := 5;
      end;
  end;
  v13 := v6 + v12;
  v14 := v13 + 31;
  Result := v14;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
