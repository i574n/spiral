program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TFun0 = class;
  TFun1 = class;
  TFun1 = class
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  TFun0 = class
    function Invoke(a0: LongInt): TFun1; virtual; abstract;
  end;
  TClosure0 = class(TFun0)  function Invoke(v0: LongInt): TFun1; override; end;
  TArray0 = array of LongInt;
  TUS0 = record tag: LongInt; c1_0: AnsiString; c1_1: TArray0; end;
  TClosure1 = class(TFun1) v0: TUS0; function Invoke(v1: LongInt): LongInt; override; end;
function ClosureCreate1(v0: TUS0): TFun1; forward;
function ClosureCreate0: TFun0; forward;
function method0(v0: TFun0): TFun1; forward;
function method1(v0: TFun0): TFun1; forward;
function method4(v0: TFun1): LongInt; forward;
function method3(v0: TFun1): LongInt; forward;
function method2(v0: TFun1; v1: TFun1): LongInt; forward;
function US0_Empty: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Item(a0: AnsiString; a1: TArray0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0; Result.c1_1 := a1;
end;
function TClosure1.Invoke(v1: LongInt): LongInt;
var
  v12: LongInt;
  v2: AnsiString;
  v3: TArray0;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
  v9: LongInt;
  v10: LongInt;
  v13: LongInt;
begin
  case v0.tag of
      0: begin
          v12 := 3;
      end;
      1: begin
          v2 := v0.c1_0;
          v3 := v0.c1_1;
          v4 := LongInt(Length(v2));
          v5 := LongInt(Length(v3));
          v6 := v4 + v5;
          v7 := v3[0];
          v8 := v6 + v7;
          v9 := v3[1];
          v10 := v8 + v9;
          v12 := v10;
      end;
  end;
  v13 := v12 + v1;
  Result := v13;
end;
function ClosureCreate1(v0: TUS0): TFun1;
var c: TClosure1;
begin
  c := TClosure1.Create; c.v0 := v0;
  Result := c;
end;
function TClosure0.Invoke(v0: LongInt): TFun1;
var
  v1: TArray0;
  tmp1: TArray0;
  v2: LongInt;
  v3: Boolean;
  v7: TUS0;
  v5: AnsiString;
begin
  tmp1 := nil;
  SetLength(tmp1, 2);
  v1 := tmp1;
  v1[0] := v0;
  v2 := v0 + 1;
  v1[1] := v2;
  v3 := v0 = 0;
  if v3 then begin
      v7 := US0_Empty;
  end else begin
      v5 := 'hi';
      v7 := US0_Item(v5, v1);
  end;
  Result := ClosureCreate1(v7);
end;
function ClosureCreate0: TFun0;
var c: TClosure0;
begin
  c := TClosure0.Create; 
  Result := c;
end;
function method0(v0: TFun0): TFun1;
begin
  Result := v0.Invoke(0);
end;
function method1(v0: TFun0): TFun1;
begin
  Result := v0.Invoke(4);
end;
function method4(v0: TFun1): LongInt;
var
  v1: LongInt;
  v2: LongInt;
begin
  v1 := v0.Invoke(2);
  v2 := v1 + 5;
  Result := v2;
end;
function method3(v0: TFun1): LongInt;
var
  v1: LongInt;
  v2: LongInt;
  v3: LongInt;
begin
  v1 := v0.Invoke(1);
  v2 := method4(v0);
  v3 := v1 + v2;
  Result := v3;
end;
function method2(v0: TFun1; v1: TFun1): LongInt;
var
  v2: LongInt;
  v3: LongInt;
  v4: LongInt;
begin
  v2 := v0.Invoke(5);
  v3 := method3(v1);
  v4 := v2 + v3;
  Result := v4;
end;
function SpiralMain: LongInt;
var
  v0: TFun0;
  v1: TFun1;
  v2: TFun1;
begin
  v0 := ClosureCreate0;
  v1 := method0(v0);
  v2 := method1(v0);
  Result := method2(v1, v2);
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
