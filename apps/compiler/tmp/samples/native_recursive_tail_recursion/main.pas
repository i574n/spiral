program SpiralGenerated;
{$mode objfpc}{$H+}

uses SysUtils;

type
  Recursive0 = class
    RefCount: LongInt;
    Tag: LongInt;
    v0: LongInt;
    v1: Recursive0;
  end;

function RecursiveCreate0_0: Recursive0;
begin
  Result := Recursive0.Create;
  Result.RefCount := 1;
  Result.Tag := 0;
end;
function RecursiveCreate0_1(v0: LongInt; v1: Recursive0): Recursive0;
begin
  Result := Recursive0.Create;
  Result.RefCount := 1;
  Result.Tag := 1;
  Result.v0 := v0;
  Result.v1 := v1;
end;
function RecursiveTag0(value: Recursive0): LongInt;
begin
  Result := value.Tag;
end;
function RecursiveField0_0(value: Recursive0): LongInt;
begin
  if value.Tag <> 1 then raise EVariantError.Create('recursive union field requested from wrong case');
  Result := value.v0;
end;
function RecursiveField0_1(value: Recursive0): Recursive0;
begin
  if value.Tag <> 1 then raise EVariantError.Create('recursive union field requested from wrong case');
  Result := value.v1;
end;
procedure RecursiveClone0(value: Recursive0);
begin
  if value <> nil then Inc(value.RefCount);
end;
procedure RecursiveDrop0(var value: Recursive0);
var
  child: Recursive0;
begin
  if value = nil then Exit;
  Dec(value.RefCount);
  if value.RefCount = 0 then
  begin
    child := nil;
    if value.Tag = 1 then child := value.v1;
    value.Free;
    value := nil;
    if child <> nil then RecursiveDrop0(child);
  end
  else value := nil;
end;

function __spiral_scc_method2_method1(__spiral_tail_state: LongInt; v0: LongInt): Recursive0;
var
  v1: LongInt;
  v2: Boolean;
  v3: Recursive0;
  __spiral_scc_arg0: LongInt;
begin
  while True do begin
    if (__spiral_tail_state = 0) then begin
      v1 := (v0 - 1);
      v2 := (v1 = 0);
      if v2 then begin
        v3 := RecursiveCreate0_0();
        Exit(RecursiveCreate0_1(7, v3));
      end else begin
        __spiral_scc_arg0 := v1;
        v0 := __spiral_scc_arg0;
        __spiral_tail_state := 1;
        Continue;
      end;
    end else begin
      v1 := (v0 - 1);
      v2 := (v1 = 0);
      if v2 then begin
        v3 := RecursiveCreate0_0();
        Exit(RecursiveCreate0_1(11, v3));
      end else begin
        __spiral_scc_arg0 := v1;
        v0 := __spiral_scc_arg0;
        __spiral_tail_state := 0;
        Continue;
      end;
    end;
  end;
end;

function method2(v0: LongInt): Recursive0;
begin
  Exit(__spiral_scc_method2_method1(0, v0));
end;

function method1(v0: LongInt): Recursive0;
begin
  Exit(__spiral_scc_method2_method1(1, v0));
end;

function method0: Recursive0;
var
  v0: LongInt;
  v1: Boolean;
  v2: Recursive0;
begin
  v0 := 1000000;
  v1 := (v0 = 0);
  if v1 then begin
    v2 := RecursiveCreate0_0();
    Exit(RecursiveCreate0_1(7, v2));
  end else begin
    Exit(method1(v0));
  end;
end;

function SpiralMain: LongInt;
var
  v0: Recursive0;
  v1: LongInt;
  v3: Boolean;
  v5: Boolean;
  v4: Boolean;
  v7: Boolean;
  v6: Boolean;
begin
  v0 := method0();
  if (RecursiveTag0(v0) = 1) then begin
    v1 := RecursiveField0_0(v0);
    RecursiveDrop0(v0);
    v3 := (v1 = 7);
    if v3 then begin
      v4 := (7 = 7);
      v5 := v4;
    end else begin
      v5 := False;
    end;
    if v5 then begin
      v6 := (11 = 11);
      v7 := v6;
    end else begin
      v7 := False;
    end;
    if v7 then begin
      Exit(0);
    end else begin
      Exit(3);
    end;
  end else begin
    RecursiveDrop0(v0);
    Exit(1);
  end;
end;

begin
  Halt(SpiralMain);
end.
